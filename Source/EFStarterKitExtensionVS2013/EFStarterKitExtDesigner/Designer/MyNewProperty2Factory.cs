﻿using System.Xml.Linq;
using System.ComponentModel.Composition;
using Microsoft.Data.Entity.Design.Extensibility;

namespace StarterKitExtension.Designer
{
    [PartCreationPolicy(CreationPolicy.Shared)]
    [Export(typeof(IEntityDesignerExtendedProperty))]
    [EntityDesignerExtendedProperty(EntityDesignerSelection.ConceptualModelEntityType)]
    class MyNewProperty2Factory : IEntityDesignerExtendedProperty
    {
        /// <summary>
        /// Called when the selected object in the Entity Data Model Designer changes and the new selection matches the object specified by the EntityDesignerExtendedProperty attribute.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public object CreateProperty(XElement element, PropertyExtensionContext context)
        {
            return new MyNewProperty2(element, context);
        }
    }
}