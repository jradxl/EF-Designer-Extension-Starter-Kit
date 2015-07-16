using Microsoft.Data.Entity.Design.Extensibility;
using StarterKitExtension.Designer;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.AttributedModel;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EFStarterKitExtDesigner.Designer
{
    [PartCreationPolicy(CreationPolicy.Shared)]
    [Export(typeof(IEntityDesignerLayer))]
    public class StarterKitLayer : IEntityDesignerLayer
    {
        public event EventHandler<ChangeEntityDesignerSelectionEventArgs> ChangeEntityDesignerSelection;

        private readonly CompositionContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="StarterKitLayer"/> class.
        /// </summary>
        public StarterKitLayer()
        {
            var catalog = new TypeCatalog(typeof(MyNewDesignSurfaceLayerPropertyFactory));
            container = new CompositionContainer(catalog);
        }

        public bool IsSealed
        {
            get { return false; }
        }

        public string Name
        {
            get { return Constants._starterKitLayerName; }
        }

        public void OnAfterLayerLoaded(XObject xObject)
        {

        }

        public void OnAfterTransactionCommitted(IEnumerable<Tuple<XObject, XObjectChange>> xmlChanges)
        {

        }

        public void OnBeforeLayerUnloaded(XObject conceptualModelXObject)
        {

        }

        public void OnSelectionChanged(XObject selection)
        {

        }

        public IList<IEntityDesignerExtendedProperty> Properties
        {
            get { return container.GetExports<IEntityDesignerExtendedProperty>().Select(e => e.Value).ToList(); }
        }

        public IServiceProvider ServiceProvider
        {
            get { return null; }
        }
    }
}
