// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace gadpime {
    
    
    public partial class MainWindow {
        
        private Gtk.Action ArchivoAction;
        
        private Gtk.Action SalirAction;
        
        private Gtk.Action ClientesAction;
        
        private Gtk.Action NuevoAction;
        
        private Gtk.Action BuscarAction;
        
        private Gtk.VBox vbox1;
        
        private Gtk.MenuBar menubar1;
        
        private Gtk.Label label1;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget gadpime.MainWindow
            Gtk.UIManager w1 = new Gtk.UIManager();
            Gtk.ActionGroup w2 = new Gtk.ActionGroup("Default");
            this.ArchivoAction = new Gtk.Action("ArchivoAction", Mono.Unix.Catalog.GetString("Archivo"), null, null);
            this.ArchivoAction.ShortLabel = Mono.Unix.Catalog.GetString("Archivo");
            w2.Add(this.ArchivoAction, null);
            this.SalirAction = new Gtk.Action("SalirAction", Mono.Unix.Catalog.GetString("Salir"), null, "gtk-quit");
            this.SalirAction.ShortLabel = Mono.Unix.Catalog.GetString("Salir");
            w2.Add(this.SalirAction, null);
            this.ClientesAction = new Gtk.Action("ClientesAction", Mono.Unix.Catalog.GetString("Clientes"), null, null);
            this.ClientesAction.ShortLabel = Mono.Unix.Catalog.GetString("Clientes");
            w2.Add(this.ClientesAction, null);
            this.NuevoAction = new Gtk.Action("NuevoAction", Mono.Unix.Catalog.GetString("Nuevo"), null, null);
            this.NuevoAction.ShortLabel = Mono.Unix.Catalog.GetString("Nuevo");
            w2.Add(this.NuevoAction, null);
            this.BuscarAction = new Gtk.Action("BuscarAction", Mono.Unix.Catalog.GetString("Buscar"), null, null);
            this.BuscarAction.ShortLabel = Mono.Unix.Catalog.GetString("Buscar");
            w2.Add(this.BuscarAction, null);
            w1.InsertActionGroup(w2, 0);
            this.AddAccelGroup(w1.AccelGroup);
            this.Name = "gadpime.MainWindow";
            this.Title = Mono.Unix.Catalog.GetString("MainWindow");
            this.WindowPosition = ((Gtk.WindowPosition)(2));
            // Container child gadpime.MainWindow.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Spacing = 6;
            // Container child vbox1.Gtk.Box+BoxChild
            w1.AddUiFromString("<ui><menubar name='menubar1'><menu action='ArchivoAction'><menuitem action='SalirAction'/></menu><menu action='ClientesAction'><menuitem action='NuevoAction'/><menuitem action='BuscarAction'/></menu></menubar></ui>");
            this.menubar1 = ((Gtk.MenuBar)(w1.GetWidget("/menubar1")));
            this.menubar1.Name = "menubar1";
            this.vbox1.Add(this.menubar1);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox1[this.menubar1]));
            w3.Position = 0;
            w3.Expand = false;
            w3.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("utilitza el menu");
            this.vbox1.Add(this.label1);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.vbox1[this.label1]));
            w4.Position = 1;
            w4.Expand = false;
            w4.Fill = false;
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 421;
            this.DefaultHeight = 300;
            this.Show();
            this.DeleteEvent += new Gtk.DeleteEventHandler(this.OnDeleteEvent);
            this.SalirAction.Activated += new System.EventHandler(this.Quit);
            this.NuevoAction.Activated += new System.EventHandler(this.ClientNew);
            this.BuscarAction.Activated += new System.EventHandler(this.ClientSearch);
        }
    }
}