﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Assignment3
{
    [DataContract] // Mark the class as serializable
    public class User : IEquatable<User>
    {
        [DataMember] // Mark properties to be serialized
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }

        /// <summary>
        /// Initializes a User object.
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">Name</param>
        /// <param name="email">Email</param>
        /// <param name="password">Plain-text password</param>
        public User(int id, string name, string email, string password)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }

        // Other methods remain unchanged
    



        /// <summary>
        /// Checks if the passed password is correct.
        /// </summary>
        /// <param name="input">Inputted password</param>
        /// <returns>True if password is correct</returns>
        public bool IsCorrectPassword(string input)
                {
                    if (string.IsNullOrEmpty(Password) == string.IsNullOrEmpty(input))
                        // Return true if both input and password are null or empty
                        return true;
                    else if (string.IsNullOrEmpty(Password) != string.IsNullOrEmpty(input))
                        // Return false if input or password is null or empty (not both)
                        return false;
                    else
                        // Otherwise, check if input and Password match.
                        return Password.Equals(input);
                }

                /// <summary>
                /// Checks if object is equal to another object.
                /// </summary>
                /// <param name="obj">Other object</param>
                /// <returns>True of this object is equal to other object</returns>
                public override bool Equals(Object other)
                {
                    if (!(other is User otherUser))
			            return false;

                    return Id == otherUser.Id && Name.Equals(otherUser.Name) && Email.Equals(otherUser.Email);
                }

                public bool Equals(User other)
                {
                    return !(other is null) &&
                           Id == other.Id &&
                           Name == other.Name &&
                           Email == other.Email &&
                           Password == other.Password;
                }

                /// <summary>
                /// Generates unique ID for User object
                /// </summary>
                /// <returns>Unique hash code/ID</returns>
                public override int GetHashCode()
                {
                    int hashCode = 825453597;
                    hashCode = hashCode * -1521134295 + Id.GetHashCode();
                    hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
                    hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
                    hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
                    return hashCode;
                }
     }
}
