namespace OOP_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1 A
            //  is a struct (a value type) ,Modifying the copied variable will not affect the original variable.


            // 1 B
            // is a class (a reference type) Modifying the object through either variable will
            // affect both, as they share the same underlying data.


            // 2 A
            // 1- Public Fields 2- Lack of Data Validation 3- No Read-Only Control 

            // 2 b 
            // Private fields hide internal implementation details
            // Public properties provide controlled access through get and set accessors 

        }
    }
}