Entity Framework Designer Starter Kit for VS 2012

There is a Starter Kit referred to in the MS documentation and in Visual Studio Gallery but I could not get it to work.
http://code.msdn.microsoft.com/DesignerExtStartKit and http://archive.msdn.microsoft.com/DesignerExtStartKit
http://msdn.microsoft.com/en-us/library/ee373851.aspx
I think it was built for VS2010 RC.

Both the VSIX manifest and the vstemplete files are now VS 2012 versions, and the projects set for .Net 4.5

I decided recover the files from the original vsix and enhance the starter kit to inclued a t4 template (that does nothing)
and a designer property on a property.

For the item template to show up in EF's Add Code Generator, the VsTemplate filename must start with "ADONETArtifactGenerator".

Build and Debug:
The VSIX project is set as startup.
The Debug config is set to start the Experimental instance, with the command-line [you will need to edit for your path].
      <path>\devenv.exe <path>\StarterKitTest1.sln /rootsuffix Exp

Operation:
When running StarterKitTest1, open the EDMX file.
You will be able to see new properties in the properties view when clicking on either the designer surface or the entity.
On the designer surface, right click and your'll be able to add a new T4 template generation template.

Issues:
(a) I cannot get the callbacks for OnModelConversion to fire. I assume that ".foo" has to be the same
name as the model, ie Model1.foo. And it is the opening of the Model1.edmx that causes the designer
to load Model1.foo from same directory.

(b) The callback OnAfterModelGenerated is only fired from the Update Wizard and never from the Generated Database wizard.
This issue is resolved. OnAfterModelGenerated is ONLY called when an *.edmx file is added to the project and the wizard used
to connect to a database and retrieve the schema for the first time. It is not called on an existing *.edmx when generating the SQL.

John
June 2013
