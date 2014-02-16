namespace IMaxwell.Core.Model
{

    /// <summary>
    /// Represents a user contact
    /// </summary>
    public class Contact : IModel
    {

        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Middle Name
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }

    }

}
