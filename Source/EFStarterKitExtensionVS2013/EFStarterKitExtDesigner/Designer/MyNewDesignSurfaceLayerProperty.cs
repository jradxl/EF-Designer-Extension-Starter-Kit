using System;
using System.Linq;
using System.Xml.Linq;
using System.ComponentModel;
using Microsoft.Data.Entity.Design.Extensibility;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StarterKitExtension.Designer
{
    class MyNewDesignSurfaceLayerProperty
    {
        private XElement _parent;
        private PropertyExtensionContext _context;

        public MyNewDesignSurfaceLayerProperty(XElement parent, PropertyExtensionContext context)
        {
            _context = context;
            _parent = parent;
        }

        [DisplayName("Starter Kit Design Surface Layer property")]
        [Description("This is the description of the Property")]
        [Category(Constants._category1)]
        public string StarterKitLayerNamespace
        {
            get { return getValue(Constants._xnStarterKitNamespace); }
            set { setValue(Constants._xnStarterKitNamespace, value); }
        }

        protected string getValue(XName xName)
        {
            return PropertyManager.GetValue(_parent, xName);
        }

        protected void setValue(XName xName, string value)
        {
            PropertyManager.SetValue(_parent, _context, xName, value);
        }

    }
}
