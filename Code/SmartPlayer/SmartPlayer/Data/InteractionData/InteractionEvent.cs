using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Data.InteractionData
{
    /// <summary>
    /// 键盘鼠标交互事件
    /// </summary>
    public class InteractionEvent
    {
        // 事件类型
        public EventType eventType { set; get; }
        // 事件发生时间
        public CustomTime happenTS { set; get; }
        // 事件参数
        public Dictionary<string, string> eventParams { set; get; }
    }

    /// <summary>
    /// 事件类型枚举类
    /// 1. 未定义事件
    /// 2. 视频暂停事件
    /// 3. 视频回放事件
    /// 4. 鼠标移动事件
    /// </summary>
    public enum EventType
    {
        UndefinedEvent, PauseEvent, RewindEvent, MouseMoveEvent
    }
}
