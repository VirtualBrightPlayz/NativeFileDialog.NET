using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace NativeFileDialog
{
    public static class OpenDialogMultiple
    {
        public static Result Open(string filterList, string defaultPath, out IEnumerable<string> outPaths) {
            outPaths = Enumerable.Empty<string>();
            unsafe {
                Dll.nfdpathset_t outPathSet;
                using var filterListHAlloc = new HAllocString(filterList);
                using var defaultPathHAlloc = new HAllocString(defaultPath);

                Dll.nfdresult_t result = Dll.NFD_DLL_OpenDialogMultiple(filterListHAlloc.Ptr, defaultPathHAlloc.Ptr, &outPathSet);

                if (result == Dll.nfdresult_t.NFD_OKAY) {
                    outPaths = outPathSet.Convert();
                    Dll.NFD_DLL_PathSet_Free(&outPathSet);
                } else if (result == Dll.nfdresult_t.NFD_ERROR) {
                    throw new NativeFileDialogException(InteropHelper.PtrToStr(Dll.NFD_DLL_GetError()));
                }

                return result.Convert();
            }
        }
    }
}