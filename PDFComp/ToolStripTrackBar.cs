using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


[System.Windows.Forms.Design.ToolStripItemDesignerAvailability(
   System.Windows.Forms.Design.ToolStripItemDesignerAvailability.ToolStrip |
   System.Windows.Forms.Design.ToolStripItemDesignerAvailability.StatusStrip)]
public class ToolStripTrackBar : ToolStripControlHost
{
     /// <summary>
    /// コンストラクタ
    /// </summary>
    public ToolStripTrackBar() : base(new TrackBar())
    {
    }

    /// <summary>
    /// ホストしているNumericUpDownコントロール
    /// </summary>
    public TrackBar TrackBar
    {
        get
        {
            return (TrackBar)Control;
        }
    }

    /// <summary>
    /// 値の設定と取得
    /// </summary>
    public int Value
    {
        get
        {
            return TrackBar.Value;
        }
        set
        {
            TrackBar.Value = value;
        }
    }

    public int Maximum
    {
        get { return TrackBar.Maximum; }
        set { TrackBar.Maximum = value; }
    }

    public int Minimum
    {
        get { return TrackBar.Minimum; }
        set { TrackBar.Minimum = value; }
    }

    public int TickFrequency
    {
        get { return TrackBar.TickFrequency; }
        set { TrackBar.TickFrequency = value; }
    }

    public int LargeChange
    {
        get { return TrackBar.LargeChange; }
        set { TrackBar.LargeChange = value; }
    }

    public int SmallChange
    {
        get { return TrackBar.SmallChange; }
        set { TrackBar.SmallChange = value; }
    }


    //ホストしているNumericUpDownのイベントをサブスクライブする
    protected override void OnSubscribeControlEvents(Control control)
    {
        base.OnSubscribeControlEvents(control);
        TrackBar trackbarControl = (TrackBar)control;
        trackbarControl.ValueChanged +=
            new EventHandler(TrackBar_OnValueChanged);
    }

    //ホストしているTrackBarのイベントをアンサブスクライブする
    protected override void OnUnsubscribeControlEvents(Control control)
    {
        base.OnUnsubscribeControlEvents(control);
        TrackBar trackbarControl = (TrackBar)control;
        trackbarControl.ValueChanged -=
            new EventHandler(TrackBar_OnValueChanged);
    }

    /// <summary>
    /// 値が変化した時に発生するイベント
    /// </summary>
    public event EventHandler ValueChanged;

    //ValueChangedイベントを発生
    private void TrackBar_OnValueChanged(object sender, EventArgs e)
    {
        if (ValueChanged != null)
        {
            ValueChanged(this, e);
        }
    }
}
