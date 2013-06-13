using System;
using System.Linq;
using System.Xml.Linq;
using System.ComponentModel;
using Microsoft.Data.Entity.Design.Extensibility;

namespace StarterKitExtension.Designer
{
    /// <summary>
    /// This class has one public property, MyIntProperty. This property is visible in the Visual Studio Properties window when a conceptual model entity type is selected in the Entity Designer or in the Model Browser.
    /// This property and its value are saved as a structured annotation in an EntityType element in the conceptual content of an .edmx document.
    /// </summary>
    class MyNewProperty2
    {
        internal static readonly string _namespace = "http://schemas.tempuri.com/MyNewProperty2";
        internal static XName _xnMyNamespace = XName.Get("MyNewProperty2", _namespace);
        internal const string _category = "Example Property 2";

        private XElement _parent;
        private PropertyExtensionContext _context;

        public MyNewProperty2(XElement parent, PropertyExtensionContext context)
        {
            _context = context;
            _parent = parent;
        }

        // This property is saved in the conceptual content of an .edmx document in the following format:
        // <EntityType>
        //  <!-- other entity properties -->
        //  <a:MyNewProperty2 xmlns:a="http://schemas.tempuri.com/MyNewProperty2">1</a:MyNewProperty2>
        // </EntityType>
        [DisplayName("My New Property 2")]
        [Description("This property is available when a conceptual model entity type is selected in the Entity Designer or the Model Browser. The property and its values are saved as a structured annotation in the EntityType element in the .edmx document.")]
        [Category(MyNewProperty2._category)]
        [DefaultValue(0)]
        public int MyIntProperty
        {
            // Read and return the property value from the structured anotation in the EntityType element.
            get
            {
                int propertyValue = 0;
                if (_parent.HasElements)
                {
                    XElement lastChild = _parent.Elements().Where<XElement>(element => element != null && element.Name == MyNewProperty2._xnMyNamespace).LastOrDefault();
                    if (lastChild != null)
                    {
                        // MyNewProperty2 element exists, so get its value.
                        int intValue = 0;
                        if (Int32.TryParse(lastChild.Value.Trim(), out intValue))
                        {
                            propertyValue = intValue;
                        }
                    }
                }
                return propertyValue;
            }

            // Write the new property value to the structured annotation in the EntityType element.
            set
            {
                int propertyValue = value;

                // Make changes to the .edmx document in an EntityDesignerChangeScope to enable undo/redo of changes.
                using (EntityDesignerChangeScope scope = _context.CreateChangeScope("Set MyNewProperty2"))
                {
                    if (_parent.HasElements)
                    {
                        XElement lastChild = _parent.Elements().Where<XElement>(element => element != null && element.Name == MyNewProperty2._xnMyNamespace).LastOrDefault();
                        if (lastChild != null)
                        {
                            // MyNewProperty2 element already exists under the EntityType element, so update its value.
                            lastChild.SetValue(propertyValue.ToString());
                        }
                        else
                        {
                            // MyNewProperty2 element does not exist, so create a new one as the last child of the EntityType element.
                            _parent.Elements().Last().AddAfterSelf(new XElement(_xnMyNamespace, propertyValue.ToString()));
                        }
                    }
                    else
                    {
                        // The EntityType element has no child elements so create a new MyNewProperty2 element as its first child.
                        _parent.Add(new XElement(_xnMyNamespace, propertyValue.ToString()));
                    }

                    // Commit the changes.
                    scope.Complete();
                }
            }
        }
    }
}