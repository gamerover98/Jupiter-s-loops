namespace Api.Manager
{
    public interface IInputManager
    {
        /// <summary>
        /// The vertical movement.
        /// <para>Must be a value in rage: [-1, +1]</para>
        /// </summary>
        /// <returns>A value between -1 and +1.</returns>
        float GetVerticalThreshold();

        /// <summary>
        /// The horizontal movement.
        /// <para>Must be a value in rage: [-1, +1]</para>
        /// </summary>
        /// <returns>A value between -1 and +1.</returns>
        float GetHorizontalThreshold();
    }
}