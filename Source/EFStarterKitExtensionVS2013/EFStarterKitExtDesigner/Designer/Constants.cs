using System;
using System.Xml.Linq;

namespace StarterKitExtension.Designer
{
    internal class Constants
    {
        internal const string _category1 = "Starter Kit Category 1";
        internal const string _category2 = "Starter Kit Category 2";

        //Designer extensions
        internal static readonly string _designerExtensionsNamespace = "http://schemas.tempuri.com/StarterKitDesignerExtension";
        internal static XName _xnStarterKitNamespace = XName.Get("StarterKitNamespace", _designerExtensionsNamespace);
 
        //Entity extensions
        internal static readonly string _entityExtensionNamespace = "http://schemas.tempuri.com/StarterKitEntityExtension";
        internal static XName _xnStarterKitClassTemplate = XName.Get("StarterKitClassTemplate", _entityExtensionNamespace);

        //Property extensions
        internal static readonly string _propertyExtensionsNamespace = "http://schemas.tempuri.com/StarterKitPropertyExtension";
        internal static XName _xnStarterKitPropertyInfo = XName.Get("StarterKitPropertyInfo", _propertyExtensionsNamespace);

        //Navigation extensions
        internal static readonly string _navigationExtensionsNamespace = "http://schemas.tempuri.com/StarterKitNavigationExtension";
        internal static XName _xnStarterKitNavigationPropertyInfo = XName.Get("StarterKitPropertyInfo", _navigationExtensionsNamespace);

    }
}
