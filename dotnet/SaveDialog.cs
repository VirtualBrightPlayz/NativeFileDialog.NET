using System.Collections.Generic;
using System.Text;

namespace NativeFileDialog {
    public static class SaveDialog {
        public static Result Open(string filterList, string defaultPath, out string outPath) {
            unsafe {
                return GenericDialog.Open(filterList, defaultPath, Dll.NFD_DLL_SaveDialog, out outPath);
            }
        }
    }
}
