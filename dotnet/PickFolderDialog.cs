using System;

namespace NativeFileDialog {
    public static class PickFolderDialog {
        public static Result Open(string defaultPath, out string outPath) {
            unsafe {
                Dll.nfdresult_t wrapper(IntPtr filters, IntPtr def, byte** outP)
                    => Dll.NFD_DLL_PickFolder(def, outP);
                
                return GenericDialog.Open("", defaultPath, wrapper, out outPath);
            }
        }
    }
}
