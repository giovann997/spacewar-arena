// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------



public partial class MainWindow {
    
    private Gtk.VBox vbox1;
    
    private Gtk.Image image1;
    
    private Gtk.Notebook notebook1;
    
    private Gtk.Label label1;
    
    private Gtk.Label label2;
    
    private Gtk.Label label3;
    
    private Gtk.Label label4;
    
    private Gtk.Label label5;
    
    private Gtk.Statusbar statusbar1;
    
    protected virtual void Build() {
        Stetic.Gui.Initialize(this);
        // Widget MainWindow
        this.Name = "MainWindow";
        this.Title = Mono.Unix.Catalog.GetString("MainWindow");
        this.WindowPosition = ((Gtk.WindowPosition)(4));
        // Container child MainWindow.Gtk.Container+ContainerChild
        this.vbox1 = new Gtk.VBox();
        this.vbox1.Name = "vbox1";
        this.vbox1.Spacing = 6;
        // Container child vbox1.Gtk.Box+BoxChild
        this.image1 = new Gtk.Image();
        this.image1.Name = "image1";
        this.image1.Pixbuf = Gdk.Pixbuf.LoadFromResource("SpacewarArena.Gtk.logo.jpg");
        this.vbox1.Add(this.image1);
        Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox1[this.image1]));
        w1.Position = 0;
        w1.Expand = false;
        w1.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.notebook1 = new Gtk.Notebook();
        this.notebook1.CanFocus = true;
        this.notebook1.Name = "notebook1";
        this.notebook1.CurrentPage = 4;
        // Notebook tab
        Gtk.Label w2 = new Gtk.Label();
        w2.Visible = true;
        this.notebook1.Add(w2);
        this.label1 = new Gtk.Label();
        this.label1.Name = "label1";
        this.label1.LabelProp = Mono.Unix.Catalog.GetString("page1");
        this.notebook1.SetTabLabel(w2, this.label1);
        this.label1.ShowAll();
        // Notebook tab
        Gtk.Label w3 = new Gtk.Label();
        w3.Visible = true;
        this.notebook1.Add(w3);
        this.label2 = new Gtk.Label();
        this.label2.Name = "label2";
        this.label2.LabelProp = Mono.Unix.Catalog.GetString("page2");
        this.notebook1.SetTabLabel(w3, this.label2);
        this.label2.ShowAll();
        // Notebook tab
        Gtk.Label w4 = new Gtk.Label();
        w4.Visible = true;
        this.notebook1.Add(w4);
        this.label3 = new Gtk.Label();
        this.label3.Name = "label3";
        this.label3.LabelProp = Mono.Unix.Catalog.GetString("page3");
        this.notebook1.SetTabLabel(w4, this.label3);
        this.label3.ShowAll();
        // Notebook tab
        Gtk.Label w5 = new Gtk.Label();
        w5.Visible = true;
        this.notebook1.Add(w5);
        this.label4 = new Gtk.Label();
        this.label4.Name = "label4";
        this.label4.LabelProp = Mono.Unix.Catalog.GetString("page4");
        this.notebook1.SetTabLabel(w5, this.label4);
        this.label4.ShowAll();
        // Notebook tab
        Gtk.Label w6 = new Gtk.Label();
        w6.Visible = true;
        this.notebook1.Add(w6);
        this.label5 = new Gtk.Label();
        this.label5.Name = "label5";
        this.label5.LabelProp = Mono.Unix.Catalog.GetString("page5");
        this.notebook1.SetTabLabel(w6, this.label5);
        this.label5.ShowAll();
        this.vbox1.Add(this.notebook1);
        Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.vbox1[this.notebook1]));
        w7.Position = 1;
        // Container child vbox1.Gtk.Box+BoxChild
        this.statusbar1 = new Gtk.Statusbar();
        this.statusbar1.Name = "statusbar1";
        this.statusbar1.Spacing = 6;
        this.vbox1.Add(this.statusbar1);
        Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.vbox1[this.statusbar1]));
        w8.Position = 2;
        w8.Expand = false;
        w8.Fill = false;
        this.Add(this.vbox1);
        if ((this.Child != null)) {
            this.Child.ShowAll();
        }
        this.DefaultWidth = 642;
        this.DefaultHeight = 503;
        this.Show();
        this.DeleteEvent += new Gtk.DeleteEventHandler(this.OnDeleteEvent);
    }
}
