using RestApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestHelper
{
    public class DataInitializer
    {
        public static List<Patient> GetAllPatients()
        {
            var patients = new List<Patient>
            {
                new Patient
                        {
                            DateOfBirth = new DateTime(1972, 10, 27),
                            FirstName = "Millicent",
                            LastName = "Hammond",
                            NhsNumber = "1111111111"
                        },
                    new Patient
                        {
                            DateOfBirth = new DateTime(1987, 2, 14),
                            FirstName = "Bobby",
                            LastName = "Atkins",
                            NhsNumber = "2222222222"
                        },
                    new Patient
                        {
                            DateOfBirth = new DateTime(1991, 12, 4),
                            FirstName = "Xanthe",
                            LastName = "Camembert",
                            NhsNumber = "3333333333"
                        }

            };
            return patients;
        }
    }


    public static class AssertObjects
    {
        public static void PropertyValuesAreEquals(object actual, object expected)
        {
            PropertyInfo[] properties = expected.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object expectedValue = property.GetValue(expected, null);
                object actualValue = property.GetValue(actual, null);

                if (actualValue is IList)
                    AssertListsAreEquals(property, (IList)actualValue, (IList)expectedValue);
                else if (!Equals(expectedValue, actualValue))
                    if (property.DeclaringType != null)
                        Assert.Fail("Property {0}.{1} does not match. Expected: {2} but was: {3}", property.DeclaringType.Name, property.Name, expectedValue, actualValue);
            }
        }

        private static void AssertListsAreEquals(PropertyInfo property, IList actualList, IList expectedList)
        {
            if (actualList.Count != expectedList.Count)
                Assert.Fail("Property {0}.{1} does not match. Expected IList containing {2} elements but was IList containing {3} elements", property.PropertyType.Name, property.Name, expectedList.Count, actualList.Count);

            for (int i = 0; i < actualList.Count; i++)
                if (!Equals(actualList[i], expectedList[i]))
                    Assert.Fail("Property {0}.{1} does not match. Expected IList with element {1} equals to {2} but was IList with element {1} equals to {3}", property.PropertyType.Name, property.Name, expectedList[i], actualList[i]);
        }
    }
}
