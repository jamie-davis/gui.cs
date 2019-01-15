using System;
using Terminal.Gui;

namespace HotKeyRepro {
    class Program {
	    static View1 _view1;
	    static Window _win;
	    static bool _removedAlready = false;

	    static void Main(string[] args)
	    {
		    Application.Init();

		    var top = Application.Top;
		    _win = new Window ("Hello") {
			    X = 0,
			    Y = 0,
			    Width = Dim.Fill (),
			    Height = Dim.Fill ()
		    };

		    _view1 = new View1();
		    _win.Add(_view1);

		    top.Add (_win);
		    Application.Run ();

	    }

	    public static void RemoveView1()
	    {
		    if (_removedAlready) {
			    MessageBox.ErrorQuery(50, 6, "Hot Key Error Reproduced", "Can't remove again!");
			    return;
		    }
		_win.Remove(_view1);
		_win.ChildNeedsDisplay();
		_win.LayoutSubviews();
		_removedAlready = true;
	    }
    }

    class View1 : View {
	    public View1()
	    {
		    var frame = new FrameView("View 1");
		    var field = new Button("View 1 button") {
			    X = 0,
			    Y = 0,
			    Width = Dim.Fill(),
			    Height = 1,
			    Clicked = Program.RemoveView1
		    };
		    frame.Add(field);
		    Add(frame);
	    }
    }
}
