using System;

namespace EntityFramework.Behavior
{
	/// <summary>
	/// Specify a behavior that apply to an entity class.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
	public abstract class BehaviorAttribute : Attribute, IBehavior
	{
		#region Construction

		/// <summary>
		/// Initialize a new instance of <see cref="BehaviorAttribute"/> class.
		/// </summary>
		protected BehaviorAttribute()
		{
		}

		#endregion

		#region IBehavior implementation

		/// <summary>
		/// Executed before an added entity is saved.
		/// </summary>
		/// <param name="entity">The entity which has been added and which is being saved.</param>
		/// <remarks>This method is implemented as an empty definition.</remarks>
		public virtual void Adding(object entity)
		{
		}

		/// <summary>
		/// Executed before an modified entity is saved.
		/// </summary>
		/// <param name="entity">The entity which has been modified and which is being saved.</param>
		/// <remarks>This method is implemented as an empty definition.</remarks>
		public virtual void Modifying(Object entity)
		{
		}

		/// <summary>
		/// Executed before an deleted entity is saved.
		/// </summary>
		/// <param name="entity">The entity which has been deleted and which is being saved.</param>
		/// <remarks>This method is implemented as an empty definition.</remarks>
		public virtual void Deleting(Object entity)
		{
		}

		#endregion
	}
}
