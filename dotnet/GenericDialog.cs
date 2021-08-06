using System;
using System.Runtime.InteropServices;

namespace NativeFileDialog
{
    internal static class GenericDialog {
        internal unsafe delegate Dll.nfdresult_t DialogFunc(IntPtr filterList, IntPtr defaultPathPtr, byte** outPath);
        
        internal static Result Open(string filterList, string defaultPath, DialogFunc dialogFunc, out string outPath) {
            outPath = "";
            unsafe {
                byte* outPathPtr = null;
                using var filterListHAlloc = new HAllocString(filterList);
                using var defaultPathHAlloc = new HAllocString(defaultPath);

                Dll.nfdresult_t result = dialogFunc(filterListHAlloc.Ptr, defaultPathHAlloc.Ptr, &outPathPtr);

                if (result == Dll.nfdresult_t.NFD_OKAY) {
                    outPath = InteropHelper.PtrToStr(outPathPtr);
                    Dll.NFD_DLL_Free((IntPtr)outPathPtr);
                } else if (result == Dll.nfdresult_t.NFD_ERROR) {
                    throw new NativeFileDialogException(InteropHelper.PtrToStr(Dll.NFD_DLL_GetError()));
                }

                return result.Convert();
            }
        }
    }
}