namespace NativeFileDialog
{
    public static class OpenDialog {
        public static Result Open(string filterList, string defaultPath, out string outPath) {
            unsafe {
                return GenericDialog.Open(filterList, defaultPath, Dll.NFD_DLL_OpenDialog, out outPath);
            }
        }
    }
}