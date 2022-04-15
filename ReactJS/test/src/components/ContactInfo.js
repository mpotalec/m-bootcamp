export default function UserList({contacts}) {
    return (
      <div>
        {contacts.map((contact) => (
          <div className="card" key={contact.phonenumber}>
            <p className="card-name">First Name: {contact.name}</p>
            <p>Email: {contact.email}</p>
            <p>Phone number: {contact.phonenumber}</p>
          </div>
        ))}
      </div>
    );
  }