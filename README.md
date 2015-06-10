EF Designer Extension Starter Kit
=================================
Updated June 2015

Entity Framework Designer Starter Kit for VS2012, VS2013 and VS2015

There is a Starter Kit referred to in the MS documentation and in Visual Studio Gallery but I could not get it to work.
http://code.msdn.microsoft.com/DesignerExtStartKit and http://archive.msdn.microsoft.com/DesignerExtStartKit
http://msdn.microsoft.com/en-us/library/ee373851.aspx
I think it was built for VS2010 RC.

Both the VSIX manifest and the vstemplete files are now VS2012, VS2013 and VS2015 versions. The projects set for .NET 4.5, .NET 4.5.1 and .NET 4.6 correspondingly.

I decided to recover the files from the original VSIX and enhance the starter kit to include a T4 template (that does nothing) and a designer property on a property.

For the item template to show up in EF's Add Code Generator from the context menu, the VsTemplate filename must start with "ADONETArtifactGenerator_".

Layer support was also added to the template.

Build and Debug:

The VSIX project is set as startup.
The Debug config is set to start the Experimental instance, with the command-line [you will need to edit for your path].
      <path>\devenv.exe <path>\StarterKitTest1.sln /rootsuffix Exp

Operation:

When running StarterKitTest1, open the EDMX file.
You will be able to see new properties in the properties view when clicking on either the designer surface or the entity.
On the designer surface, right click and your'll be able to add a new T4 template generation template.

Issues:

(a) I cannot get the callbacks for OnModelConversion to fire. I assume that ".foo" has to be the same name as the model, ie Model1.foo.
This has been agreed with Microsoft Entity Framework as a bug.


John 

Updated by Andrii

June 2015
