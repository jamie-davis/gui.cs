using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Sockets;
using Terminal.Gui;

namespace ListRepro {
    class Program {
	static void Main(string[] args)
	{
		Application.Init();

		var top = Application.Top;
		var win = new Window ("Hello") {
			X = 0,
			Y = 0,
			Width = Dim.Fill (),
			Height = Dim.Fill ()
		};

		win.Add(new View1());

		top.Add (win);
		Application.Run ();

	}
    }

    class View1 : View {
	    public View1()
	    {
		    var frame = new FrameView("View 1");
		    var view2 = new View2()
		    {
			    X = 0,
			    Y = 1,
			    Width = Dim.Fill(),
			    Height = Dim.Fill()
		    };
		    var field = new TextField("View 1 field") {
			    X = 0,
			    Y = 0,
			    Width = Dim.Fill(),
			    Height = 1
		    };
		    frame.Add(field, view2);
		    Add(frame);
	    }
    }

    class View2 : View {
	    public View2()
	    {
		    var frame = new FrameView("View 2");
		    var view3 = new View3()
		    {
			    X = 0,
			    Y = 1,
			    Width = Dim.Fill(),
			    Height = Dim.Fill()
		    };
		    var field = new TextField("View 2 field") {
			    X = 0,
			    Y = 0,
			    Width = Dim.Fill(),
			    Height = 1
		    };
		    frame.Add(field, view3);
		    Add(frame);
	    }
    }

    class View3 : View {
	    public View3()
	    {
		    var frame = new FrameView("List");
		    var list = new List<string> {"one", "two", "three"};
		    var listView = new ListView(list) {
			    X = 0,
			    Y = 0,
			    Width = Dim.Fill(),
			    Height = 6
		    };

		    frame.Add(listView);
		    Add(frame);
	    }
    }
}
