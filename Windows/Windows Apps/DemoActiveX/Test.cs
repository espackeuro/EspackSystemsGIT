using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace DemoActiveX
{
    [ProgId("DemoActiveX.Test")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [Guid("6C69C2CD-4EDE-4A29-9F11-1B25D6E2A01B")]
    public class Test
    {
        [ComVisible(true)]
        public String SayHello()
        {
            return "Hello World!";
        }
    }
}
