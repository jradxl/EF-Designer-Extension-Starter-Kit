
namespace StarterKitTest2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Do Nothing Example for the Starter Kit Entity Designer Extention
            //VS2012, 7th May 2013

            //The VSIX must be installed first!!
            //Change the path in the Properties:Debug section of the VSIX Project. Make it the Startup projet.
            //It will then start this project running in the experimental instance, and you can continue below.

            //Open Model1.edmx in the Entity Designer.
            //Click on white designer surface, and scroll properties window to bottom.
            //You should see a property 'Starter Kit Design Surface prop' with the value of "SomeString"
            //Click on the Entity
            //and you should see 'New Property'  with the value of True
            //and 'New Property 2' with the value of 123
            //Don't worry about Error 2062 if you build, as there is no need to connect to a database.
            //VS2012 defaults to the DbContext generator, and you can see the T4 template output in Model1.Context.cs and TESTENTITY.cs
            //This generated code is not affected by the VSIX. The VSIX is a do nothing extension, except for the properties.

            //Now return to the EDMX and right click the design surface.
            //Select Add Code Generation Item, and from the Add New Item dialog select StarterKitExtension.Template.
            //a new StarterKitExtension1.tt will be added, and when the EDMX is saved, the T4 template will run.
            //You'll see the dummy C# code in the resulting StarterKitExtension.cs file, with the current date and time in a commment.
        }
    }
}
