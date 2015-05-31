using Microsoft.Data.Entity.Design.Extensibility;
using System.ComponentModel.Composition;
using System.Xml.Linq;

namespace StarterKitExtension.Designer
{
    [EntityDesignerLayer(Constants._starterKitLayerName)]
    [PartCreationPolicy(CreationPolicy.Shared)]
    [Export(typeof(IEntityDesignerExtendedProperty))]
    [EntityDesignerExtendedProperty(EntityDesignerSelection.DesignerSurface)]
    class MyNewDesignSurfaceLayerPropertyFactory : IEntityDesignerExtendedProperty
    {
        /// <summary>
        /// Called when the selected object in the Entity Data Model Designer
        /// changes and the new selection matches the object specified by the
        /// EntityDesignerExtendedProperty attribute.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public object CreateProperty(XElement element, PropertyExtensionContext context)
        {
            return new MyNewDesignSurfaceLayerProperty(element, context);
        }
    }
}
