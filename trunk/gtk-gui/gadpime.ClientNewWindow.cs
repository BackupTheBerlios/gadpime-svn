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
    
    
    public partial class ClientNewWindow {
        
        private Gtk.Action FicheroAction;
        
        private Gtk.Action GuardarAction;
        
        private Gtk.Action CerrarAction;
        
        private Gtk.VBox vbox2;
        
        private Gtk.MenuBar menubar1;
        
        private Gtk.Table table1;
        
        private Gtk.Entry EntryClientName;
        
        private Gtk.Entry EntryClientSurname1;
        
        private Gtk.Entry EntryClientSurname2;
        
        private Gtk.Label LabelClientName;
        
        private Gtk.Label LabelClientSurname1;
        
        private Gtk.Label LabelClientSurname2;
        
        private Gtk.HBox hbox3;
        
        private Gtk.Button ButtonClientSave;
        
        private Gtk.Button ButtonClientClose;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget gadpime.ClientNewWindow
            Gtk.UIManager w1 = new Gtk.UIManager();
            Gtk.ActionGroup w2 = new Gtk.ActionGroup("Default");
            this.FicheroAction = new Gtk.Action("FicheroAction", Mono.Unix.Catalog.GetString("Fichero"), null, null);
            this.FicheroAction.ShortLabel = Mono.Unix.Catalog.GetString("Fichero");
            w2.Add(this.FicheroAction, null);
            this.GuardarAction = new Gtk.Action("GuardarAction", Mono.Unix.Catalog.GetString("Guardar"), null, "gtk-save");
            this.GuardarAction.ShortLabel = Mono.Unix.Catalog.GetString("Guardar");
            w2.Add(this.GuardarAction, null);
            this.CerrarAction = new Gtk.Action("CerrarAction", Mono.Unix.Catalog.GetString("Cerrar"), null, "gtk-stop");
            this.CerrarAction.ShortLabel = Mono.Unix.Catalog.GetString("Cerrar");
            w2.Add(this.CerrarAction, null);
            w1.InsertActionGroup(w2, 0);
            this.AddAccelGroup(w1.AccelGroup);
            this.Name = "gadpime.ClientNewWindow";
            this.Title = Mono.Unix.Catalog.GetString("Client");
            this.WindowPosition = ((Gtk.WindowPosition)(2));
            // Container child gadpime.ClientNewWindow.Gtk.Container+ContainerChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            w1.AddUiFromString("<ui><menubar name='menubar1'><menu action='FicheroAction'><menuitem action='GuardarAction'/><menuitem action='CerrarAction'/></menu></menubar></ui>");
            this.menubar1 = ((Gtk.MenuBar)(w1.GetWidget("/menubar1")));
            this.menubar1.Name = "menubar1";
            this.vbox2.Add(this.menubar1);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox2[this.menubar1]));
            w3.Position = 0;
            w3.Expand = false;
            w3.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.table1 = new Gtk.Table(((uint)(3)), ((uint)(2)), false);
            this.table1.Name = "table1";
            this.table1.RowSpacing = ((uint)(6));
            this.table1.ColumnSpacing = ((uint)(6));
            // Container child table1.Gtk.Table+TableChild
            this.EntryClientName = new Gtk.Entry();
            this.EntryClientName.CanFocus = true;
            this.EntryClientName.Name = "EntryClientName";
            this.EntryClientName.IsEditable = true;
            this.EntryClientName.InvisibleChar = '●';
            this.table1.Add(this.EntryClientName);
            Gtk.Table.TableChild w4 = ((Gtk.Table.TableChild)(this.table1[this.EntryClientName]));
            w4.LeftAttach = ((uint)(1));
            w4.RightAttach = ((uint)(2));
            w4.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.EntryClientSurname1 = new Gtk.Entry();
            this.EntryClientSurname1.CanFocus = true;
            this.EntryClientSurname1.Name = "EntryClientSurname1";
            this.EntryClientSurname1.IsEditable = true;
            this.EntryClientSurname1.InvisibleChar = '●';
            this.table1.Add(this.EntryClientSurname1);
            Gtk.Table.TableChild w5 = ((Gtk.Table.TableChild)(this.table1[this.EntryClientSurname1]));
            w5.TopAttach = ((uint)(1));
            w5.BottomAttach = ((uint)(2));
            w5.LeftAttach = ((uint)(1));
            w5.RightAttach = ((uint)(2));
            w5.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.EntryClientSurname2 = new Gtk.Entry();
            this.EntryClientSurname2.CanFocus = true;
            this.EntryClientSurname2.Name = "EntryClientSurname2";
            this.EntryClientSurname2.IsEditable = true;
            this.EntryClientSurname2.InvisibleChar = '●';
            this.table1.Add(this.EntryClientSurname2);
            Gtk.Table.TableChild w6 = ((Gtk.Table.TableChild)(this.table1[this.EntryClientSurname2]));
            w6.TopAttach = ((uint)(2));
            w6.BottomAttach = ((uint)(3));
            w6.LeftAttach = ((uint)(1));
            w6.RightAttach = ((uint)(2));
            w6.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.LabelClientName = new Gtk.Label();
            this.LabelClientName.Name = "LabelClientName";
            this.LabelClientName.LabelProp = Mono.Unix.Catalog.GetString("Nom");
            this.table1.Add(this.LabelClientName);
            Gtk.Table.TableChild w7 = ((Gtk.Table.TableChild)(this.table1[this.LabelClientName]));
            w7.XOptions = ((Gtk.AttachOptions)(4));
            w7.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.LabelClientSurname1 = new Gtk.Label();
            this.LabelClientSurname1.Name = "LabelClientSurname1";
            this.LabelClientSurname1.LabelProp = Mono.Unix.Catalog.GetString("Cognom1");
            this.table1.Add(this.LabelClientSurname1);
            Gtk.Table.TableChild w8 = ((Gtk.Table.TableChild)(this.table1[this.LabelClientSurname1]));
            w8.TopAttach = ((uint)(1));
            w8.BottomAttach = ((uint)(2));
            w8.XOptions = ((Gtk.AttachOptions)(4));
            w8.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.LabelClientSurname2 = new Gtk.Label();
            this.LabelClientSurname2.Name = "LabelClientSurname2";
            this.LabelClientSurname2.LabelProp = Mono.Unix.Catalog.GetString("Cognom2");
            this.table1.Add(this.LabelClientSurname2);
            Gtk.Table.TableChild w9 = ((Gtk.Table.TableChild)(this.table1[this.LabelClientSurname2]));
            w9.TopAttach = ((uint)(2));
            w9.BottomAttach = ((uint)(3));
            w9.XOptions = ((Gtk.AttachOptions)(4));
            w9.YOptions = ((Gtk.AttachOptions)(4));
            this.vbox2.Add(this.table1);
            Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.vbox2[this.table1]));
            w10.Position = 1;
            w10.Expand = false;
            w10.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.hbox3 = new Gtk.HBox();
            this.hbox3.Name = "hbox3";
            this.hbox3.Spacing = 6;
            // Container child hbox3.Gtk.Box+BoxChild
            this.ButtonClientSave = new Gtk.Button();
            this.ButtonClientSave.CanFocus = true;
            this.ButtonClientSave.Name = "ButtonClientSave";
            this.ButtonClientSave.UseStock = true;
            this.ButtonClientSave.UseUnderline = true;
            this.ButtonClientSave.Label = "gtk-save";
            this.hbox3.Add(this.ButtonClientSave);
            Gtk.Box.BoxChild w11 = ((Gtk.Box.BoxChild)(this.hbox3[this.ButtonClientSave]));
            w11.Position = 0;
            w11.Expand = false;
            w11.Fill = false;
            // Container child hbox3.Gtk.Box+BoxChild
            this.ButtonClientClose = new Gtk.Button();
            this.ButtonClientClose.CanFocus = true;
            this.ButtonClientClose.Name = "ButtonClientClose";
            this.ButtonClientClose.UseStock = true;
            this.ButtonClientClose.UseUnderline = true;
            this.ButtonClientClose.Label = "gtk-close";
            this.hbox3.Add(this.ButtonClientClose);
            Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.hbox3[this.ButtonClientClose]));
            w12.Position = 1;
            w12.Expand = false;
            w12.Fill = false;
            this.vbox2.Add(this.hbox3);
            Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.vbox2[this.hbox3]));
            w13.Position = 2;
            w13.Expand = false;
            w13.Fill = false;
            this.Add(this.vbox2);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 400;
            this.DefaultHeight = 261;
            this.Show();
            this.CerrarAction.Activated += new System.EventHandler(this.Close);
            this.EntryClientName.Changed += new System.EventHandler(this.ClientDataChanged);
            this.ButtonClientSave.Clicked += new System.EventHandler(this.ClientSave);
            this.ButtonClientClose.Clicked += new System.EventHandler(this.Close);
        }
    }
}