using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace EntityFramework.Behavior
{
	/// <summary>
	/// Represent a <see cref="DbContext"/> that can apply behaviors defined on entities before that they are saved.
	/// </summary>
	public class BehaviorDbContext : DbContext
	{
		#region Construction

		/// <summary>
		/// Initialize a new intsnace of <see cref="BehaviorDbContext"/> class.
		/// </summary>
		public BehaviorDbContext()
		{
			// Register handler when changes are saved to the data source.
			((IObjectContextAdapter)this).ObjectContext.SavingChanges += new EventHandler(this.context_SavingChanges);
		}

		#endregion

		#region Private

		/// <summary>
		/// Handles the SavingChanges event.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void context_SavingChanges(object sender, EventArgs e)
		{
			IEnumerable<DbEntityEntry> entries;

			// Get all the entities tracked by this context
			entries = this.ChangeTracker.Entries();

			// Browse entities and determine for each if behavior are to apply.
			foreach (DbEntityEntry entry in entries)
			{
				Object entity = entry.Entity;
				EntityState state = entry.State;
				if (state == EntityState.Added || state == EntityState.Modified || state == EntityState.Deleted)
				{
					// Retrieve behaviors attached to the entity.
					IEnumerable<IBehavior> behaviors = this.GetBehaviors(entity);
					// Apply the adapted action of each behavior.
					foreach (IBehavior behavior in behaviors)
					{
						switch (state)
						{
							case EntityState.Added:
								behavior.Adding(entity);
								break;
							case EntityState.Modified:
								behavior.Modifying(entity);
								break;
							case EntityState.Deleted:
								behavior.Deleting(entity);
								break;
						}
					}
				}
			}
		}

		/// <summary>
		/// Return all the behaviors defined for the specified entity.
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		private IEnumerable<IBehavior> GetBehaviors(Object entity)
		{
			return entity.GetType().GetCustomAttributes(typeof(BehaviorAttribute), true).Cast<IBehavior>();
		}

		#endregion
	}
}
