using System;
using System.Collections.Generic;
using System.Text;

namespace NativeFileDialog
{
    internal static class InteropHelper {
        internal static unsafe string PtrToStr(byte* cstr) {
            byte* nullPos = cstr;
            while (*nullPos != 0) { nullPos++; }
            return Encoding.UTF8.GetString(cstr, (int)(nullPos-cstr));
        }

        internal static Result Convert(this Dll.nfdresult_t internalResult)
            => internalResult switch {
                Dll.nfdresult_t.NFD_OKAY => Result.Okay,
                Dll.nfdresult_t.NFD_CANCEL => Result.Cancel,
                _ => throw new ArgumentOutOfRangeException(nameof(internalResult), internalResult, null)
            };

        internal static unsafe IEnumerable<string> Convert(this Dll.nfdpathset_t internalPathSet) {
            nuint count = Dll.NFD_DLL_PathSet_GetCount(&internalPathSet);
            string[] retVal = new string[count];
            for (nuint i = 0; i < count; i++) {
                byte* pathPtr = Dll.NFD_DLL_PathSet_GetPath(&internalPathSet, i);
                retVal[i] = InteropHelper.PtrToStr(pathPtr);
            }
            return retVal;
        }
    }
}