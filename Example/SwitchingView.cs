using System.Collections.Generic;
using System.Linq;
using Terminal.Gui;

namespace Terminal {
    class SwitchingView : View {
	    private Dictionary<string, View> views = new Dictionary<string, View> {
		    {"One", MakeViewOne()},
		    {"Two", MakeViewTwo()},
	    };

	    static View MakeViewOne()
	    {
		    var label1 = new Label(0,0, "Field 1");
		    var field1 = new TextField(10, 0, 15, "value");
		    var label2 = new Label(0,2, "Field 2");
		    var field2 = new TextField(10, 2, 15, "value 2");
		    var viewOne = new View {{label1, field1, label2, field2}};
		    return viewOne;
	    }

	    static View MakeViewTwo()
	    {
		    var field1 = new CheckBox(0, 0, "Do one");
		    var field2 = new CheckBox(0, 2, "Do two");
		    var viewTwo = new View {{field1, field2}};
		    return viewTwo;
	    }

	    View host;

	    public View Current { get; private set; }

	    public SwitchingView()
	    {
		    var x = 0;
		    foreach (var viewPair in views) {
			Add(new Button(x, 0, viewPair.Key) { Clicked = () => SwitchTo(viewPair.Value) });
			x += 10;
		    }

		    host = new View {
			X = 0,
			Y = 1,
			Width = Dim.Fill(),
			Height = Dim.Fill()
		    };

		    Add(host);
	    }

	    private void SwitchTo(View view)
	    {
		    if (ReferenceEquals(Current, view))
			    return;

		    if (host.Subviews.Any()) {
			    host.RemoveAll();
		    }

		    host.Add(view);
		    SetNeedsDisplay();
		    LayoutSubviews();
		    Current = view;
	    }

	    #region Overrides of View

	    public override void Redraw(Rect region)
	    {
		    Driver.SetAttribute(ColorScheme.Normal);
		    Clear(region);
		    base.Redraw(region);
	    }

	    #endregion
    }
}
