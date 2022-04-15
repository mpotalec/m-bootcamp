import { useState } from 'react';

export default function UserForm({addContact}){
    const[contactInfo, setContactInfo] = useState({
        name: "",
        email: "",
        phonenumber:"",
    });

    const handleChange = (event) =>{
        setContactInfo({...contactInfo, [event.target.name]: event.target.value});
    };
    const handleSubmit = (event) => {
        event.preventDefault();
        addContact(contactInfo);
        setContactInfo({ name: "", email: "", phonenumber: "" });
      };
      return (
          <div className = "form-container">
              <form onSubmit = {handleSubmit}>
                  <div>
                      <h3>Contact form</h3>
                  </div>
                  <div>
                      <input
                      type="text"
                      name="name"
                      placeholder="Name"
                      value = {contactInfo.name}
                      onChange = {handleChange}
                      required
                      />
                  </div>
                  <div>
                     <input
                     type="email"
                     name="email"
                     placeholder="Email"
                     value={contactInfo.email}
                     onChange={handleChange}
                     required

                     />
                  </div>
                  <div>
                     <input
                     type="number"
                     name="phonenumber"
                     placeholder="Phone Number"
                     value={contactInfo.phonenumber}
                     onChange={handleChange}
                     required

                     />
                   </div>
                   <div>
            <button>Submit Contact</button>
                   </div>
                </form>
          </div>
      );
}