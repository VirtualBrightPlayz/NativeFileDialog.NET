using System;
using System.Runtime.InteropServices;

namespace NativeFileDialog
{
    internal static class Dll {
        private const string DllName = "nfd";

        [StructLayout(LayoutKind.Sequential)]
        internal struct nfdpathset_t {
            public IntPtr buf;     //nfdchar_t*
            public IntPtr indices; //size_t*
            public IntPtr count;   //size_t
        }

        internal enum nfdresult_t {
            NFD_ERROR  = 0,       /* programmatic error */
            NFD_OKAY   = 1,       /* user pressed okay, or successful return */
            NFD_CANCEL = 2        /* user pressed cancel */
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern unsafe nfdresult_t NFD_DLL_OpenDialog(IntPtr filterList, IntPtr defaultPath, byte** outPath);
        /* nfdresult_t NFD_DLL_OpenDialog( const nfdchar_t *filterList,
                            const nfdchar_t *defaultPath,
                            nfdchar_t **outPath ); */

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern unsafe nfdresult_t NFD_DLL_OpenDialogMultiple(IntPtr filterList, IntPtr defaultPath, Dll.nfdpathset_t* outPaths);
        /* nfdresult_t NFD_DLL_OpenDialogMultiple( const nfdchar_t *filterList,
                                    const nfdchar_t *defaultPath,
                                    nfdpathset_t *outPaths ); */

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern unsafe nfdresult_t NFD_DLL_SaveDialog(IntPtr filterList, IntPtr defaultPath, byte** outPath);
        /* nfdresult_t NFD_DLL_SaveDialog( const nfdchar_t *filterList,
                            const nfdchar_t *defaultPath,
                            nfdchar_t **outPath ); */
        
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern unsafe nfdresult_t NFD_DLL_PickFolder(IntPtr defaultPath, byte** outPath);
        /* nfdresult_t NFD_DLL_PickFolder( const nfdchar_t *defaultPath,
                            nfdchar_t **outPath); */

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern unsafe byte* NFD_DLL_GetError();
        /* const char * NFD_DLL_GetError( void ); */

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern unsafe nuint NFD_DLL_PathSet_GetCount(nfdpathset_t* pathSet);
        /* size_t       NFD_DLL_PathSet_GetCount( const nfdpathset_t *pathSet ); */

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern unsafe byte* NFD_DLL_PathSet_GetPath(nfdpathset_t* pathSet, nuint index);
        /* nfdchar_t  * NFD_DLL_PathSet_GetPath( const nfdpathset_t *pathSet, size_t index ); */

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern unsafe void NFD_DLL_PathSet_Free(nfdpathset_t* pathSet);
        /* void         NFD_DLL_PathSet_Free( nfdpathset_t *pathSet ); */

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFD_DLL_Free(IntPtr ptr);
        /* void    NFD_DLL_Free( void *ptr ); */
    }
}
