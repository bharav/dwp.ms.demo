using System;
using System.Collections.Generic;
using System.Text;
using dwp.ms.demo.registration.domain.SeedWork;

namespace dwp.ms.demo.registration.domain.AggregatesModel.RegistrationAggregate
{
   public class Registration: Entity, IAggregateRoot
    {
        private string _regNo;
        private string _name;
        private string _address;
        private string _phone;
        private string _chesisNo;
        private string _engineNo;

        public Registration(string regNo, string name, string address, string phone, string chesisNo, string engineNo) {
            _regNo = regNo;
            _name = name;
            _address = address;
            _phone = phone;
            _chesisNo = chesisNo;
            _engineNo = engineNo;
        }
      
    }
}
