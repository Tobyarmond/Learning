using System;

namespace Learning
{
    public static class bytestuff
    {
        // Bytes can be used for containing 8 bools by using each induvidual bit as an induvidual bool
        // This is how you implicitly give binary 0b
        // You cannot give binary numbers without the prefix 0b
        private static byte bob = 0b00101111;
        // You can give binary numbers to ints or others the same way as assigning a byte.
        private static int bitbool = 0b00010001;
        private static byte shiftit = 0b00110011;
        // This is a bitshift (which basically moves a everything over the amount specified) and uses the >> or <<
        private static int shiftit1 = shiftit >> 2;
        // It doesn't really like using bytes, and instead has forced me to use an int here
        
        
        // You can use logical bitwise operators to evaluate to another byte rather than a boolean like they normally
        // evaluate to. To do this you simply use a single & or a single | etc.
        private static int andstuff()
        {
            return bitbool & shiftit;
        }

        private static int orstuff()
        {
            return bitbool | shiftit;
        }
        private static int answer = andstuff();
        private static int answer1 = orstuff();

        // The real way of using bytes in this way is to add a [Flags] attribute and then have a enum with the definitions
        // of each induvidual bit.
        [Flags]
        public enum ForumPrivelages
        {
            CreatePosts =     1 << 0, // 1
            EditOwnPosts =    1 << 1, // 2
            VoteOnPosts =     1 << 2, // 4
            EditOthersPosts = 1 << 3, // 8
            DeletePosts =     1 << 4, // 16
            CreateThreads =   1 << 5, // 32
            Suspended =       1 << 6, // 64
            
            // remember that bytes are like this 00000001 = 1 therefore << makes larger numbers (mostly) not smaller.
            
            // Note: we can also add shortcuts here:
            None = 0,
            BasicUser = CreatePosts | EditOwnPosts | VoteOnPosts,
            Administrator = BasicUser | EditOthersPosts | DeletePosts | CreateThreads
        }

        
        
    }
}