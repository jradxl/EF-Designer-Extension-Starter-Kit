using Microsoft.Data.Entity.Design.Extensibility;
using System.ComponentModel.Composition;

namespace StarterKitExtension.Designer
{
    [Export(typeof(IModelConversionExtension))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    [ModelFileExtension(".foo")]
    class ModelConversionExtension : IModelConversionExtension
    {

        /* These callbacks do not appear to be working */

        /// <summary>
        /// Called after the contents of a custom file have been loaded, but before the contents are converted
        /// to an .edmx document for display in the Entity Designer.
        /// </summary>
        /// <param name="context">Provides file and Visual Studio project information.</param>
        void IModelConversionExtension.OnAfterFileLoaded(ModelConversionExtensionContext context)
        {
            // context.OriginalDocument = Contents of the custom file as a string.
            //                            This is for reference only and cannot be modified.
            //
            // context.CurrentDocument = Contents of the converted file as an XDocument.
            //                           This should be a valid .edmx document.
        }

        /// <summary>
        /// Called right before the file will be saved to disk.
        /// </summary>
        /// <param name="context">Provides file and Visual Studio project information.</param>
        void IModelConversionExtension.OnBeforeFileSaved(ModelConversionExtensionContext context)
        {
            // context.CurrentDocument = The .edmx content (as an XDocument) created by the Entity Designer.
            //                           This is for reference and cannot be modified.
            //
            // context.OriginalDocument = The .edmx (as a string) after it has been converted to a custom file format.
        }
    }
}
