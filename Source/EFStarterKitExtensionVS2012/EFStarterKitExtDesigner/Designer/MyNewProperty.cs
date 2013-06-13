using System;
using System.Linq;
using System.Xml.Linq;
using System.ComponentModel;
using Microsoft.Data.Entity.Design.Extensibility;

namespace StarterKitExtension.Designer
{
    /// <summary>
    /// This class has one public property, MyBoolProperty. 
    /// This property is visible in the Visual Studio Properties window when a 
    /// conceptual model entity type is selected in the Entity Designer or in the Model Browser.
    /// This property and its value are saved as a structured annotation in an EntityType 
    /// element in the conceptual content of an .edmx document.
    /// </summary>
    class MyNewProperty
    {
        internal static readonly string _namespace = "http://schemas.tempuri.com/MyNewProperty";
        internal static XName _xnMyNamespace = XName.Get("MyNewProperty", _namespace);
        internal const string _category = "Example Property";

        private XElement _parent;
        private PropertyExtensionContext _context;

        public MyNewProperty(XElement parent, PropertyExtensionContext context)
        {
            _context = context;
            _parent = parent;
        }

        // This property is saved in the conceptual content of an .edmx document in the following format:
        // <EntityType>
        //  <!-- other entity properties -->
        //  <MyNewProperty xmlns="http://schemas.tempuri.com/MyNewProperty">True</MyNewProperty>
        // </EntityType>
        [DisplayName("My New Property")]
        [Description("This property is available when a C-Side EntityType is selected in the Entity Designer canvas or the Model Browser. Its values are saved as a structured annotation in the <EntityType> in the EDMX file.")]
        [Category(MyNewProperty._category)]
        [DefaultValue(false)]
        public bool MyBoolProperty
        {
            // Read and return the property value from the structured annotation in the EntityType element.
            get
            {
                bool propertyValue = false;
                if (_parent.HasElements)
                {
                    XElement lastChild = _parent.Elements().Where<XElement>(element => element != null && element.Name == MyNewProperty._xnMyNamespace).LastOrDefault();
                    if (lastChild != null)
                    {
                        // MyNewProperty element exists, so get its value.
                        bool boolValue = false;
                        if (Boolean.TryParse(lastChild.Value.Trim(), out boolValue))
                        {
                            propertyValue = boolValue;
                        }
                    }
                }
                return propertyValue;
            }

            // Write the new property value to the structured annotation in the EntityType element.
            set
            {
                bool propertyValue = value;

                // Make changes to the .edmx document in an EntityDesignerChangeScope to enable undo/redo of changes.
                using (EntityDesignerChangeScope scope = _context.CreateChangeScope("Set MyNewProperty"))
                {
                    if (_parent.HasElements)
                    {
                        XElement lastChild = _parent.Elements().Where<XElement>(element => element != null && element.Name == MyNewProperty._xnMyNamespace).LastOrDefault();
                        if (lastChild != null)
                        {
                            // MyNewProperty element already exists under the EntityType element, so update its value.
                            lastChild.SetValue(propertyValue.ToString());
                        }
                        else
                        {
                            // MyNewProperty element does not exist, so create a new one as the last child of the EntityType element.
                            _parent.Elements().Last().AddAfterSelf(new XElement(_xnMyNamespace, propertyValue.ToString()));
                        }
                    }
                    else
                    {
                        // The EntityType element has no child elements so create a new MyNewProperty element as its first child.
                        _parent.Add(new XElement(_xnMyNamespace, propertyValue.ToString()));
                    }

                    // Commit the changes.
                    scope.Complete();
                }
            }
        }
    }
}
