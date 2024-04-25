using System;

namespace Api.Entity
{
    /// <summary>Represents a living entity, such as the player.</summary>
    /// <typeparam name="THealth">The type representing health, such as a numerical value.</typeparam>
    public interface ILiving<THealth>
        where THealth : struct, IComparable, IFormattable, IConvertible
    {
        /// <summary>
        /// Gets the entity's current health, ranging from 0 to the maximum health
        /// returned by GetMaxHealth(), where 0 represents dead.</summary>
        /// <returns>The current health, ranging from 0 to the maximum.</returns>
        THealth GetHealth();

        /// <summary>
        /// Sets the entity's current health, ranging from 0 to the maximum health
        /// returned by GetMaxHealth(), where 0 represents dead.</summary>
        /// <param name="health">The new current health, ranging from 0 to the maximum.</param>
        void SetHealth(THealth health);

        /// <summary>Gets the maximum health that this entity can have.</summary>
        /// <returns>The maximum health.</returns>
        THealth GetMaxHealth();

        /// <summary>
        /// Sets the maximum health that this entity can have.
        /// <para>If the current health of the entity exceeds the specified maximum, it will be set to that value.</para>
        /// </summary>
        /// <param name="maxHealth">The amount of health to set as the maximum.</param>
        void SetMaxHealth(THealth maxHealth);

        /// <summary>Returns true if this entity's health is 0.</summary>
        /// <returns>True if the entity is dead.</returns>
        bool IsDead();
    }
}