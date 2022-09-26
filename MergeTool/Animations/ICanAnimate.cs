using MergeTool.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTool.Animations
{
    /// <summary>
    /// Interface for a page which can animate. Use it for every container which must be animated
    /// </summary>
    public interface ICanAnimate
    {
        AnimateSlideProperty.Animation AnimationIn { get; set; }
        AnimateSlideProperty.Animation AnimationOut { get; set; }
        void AnimateIn();
        void AnimateOut();
    }
}
