using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NativeFileDialog
{
    public class HAllocString : IDisposable
    {
        public readonly IntPtr Ptr;

        public HAllocString(string str) {
            byte[] bytes = Encoding.UTF8.GetBytes(str+"\0");
            Ptr = Marshal.AllocHGlobal(bytes.Length);
            Marshal.Copy(bytes, 0, Ptr, bytes.Length);
        }

        private void ReleaseUnmanagedResources() {
            Marshal.FreeHGlobal(Ptr);
        }

        public void Dispose() {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~HAllocString() {
            ReleaseUnmanagedResources();
        }
    }
}