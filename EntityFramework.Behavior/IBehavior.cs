using System;

namespace EntityFramework.Behavior
{
	/// <summary>
	/// Defines a object that can add behavior to entities. This allows factoring capabilities that
	/// can be automated and applied to several types of entities.
	/// </summary>
	public interface IBehavior
	{
		/// <summary>
		/// Executed before an added entity is saved.
		/// </summary>
		/// <param name="entity">The entity which has been added and which is being saved.</param>
		void Adding(Object entity);

		/// <summary>
		/// Executed before an modified entity is saved.
		/// </summary>
		/// <param name="entity">The entity which has been modified and which is being saved.</param>
		void Modifying(Object entity);

		/// <summary>
		/// Executed before an deleted entity is saved.
		/// </summary>
		/// <param name="entity">The entity which has been deleted and which is being saved.</param>
		void Deleting(Object entity);
	}
}
