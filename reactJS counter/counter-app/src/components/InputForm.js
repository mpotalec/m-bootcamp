import React from "react";

class InputForm extends React.Component {
  state = {
    firstName: "",
    lastName: "",
    textArea:"",
    phoneNumber:"",
    person: [],
  };

  handleFirstNameChange = (event) => {
    this.setState({
      firstName: event.target.value
    });
  };

  handleLastNameChange = (event) => {
    this.setState({
      lastName: event.target.value
    });
  };

  handleTextAreaChange = (event) => {
      this.setState({
          textArea: event.target.value
      })
  }

  handlePhoneNumberChange = (event) =>{
      this.setState({
          phoneNumber:event.target.value
      })
  }

  handleSubmit = (event) => {
    event.preventDefault();
    let newArray = {
      firstName: this.state.firstName,
      lastName: this.state.lastName,
      textArea: this.state.textArea,
      phoneNumber: this.state.phoneNumber
    };
    let emptyArray = this.state.person.concat(newArray);
    this.setState({ person: emptyArray });
  };

  people = () => {
    return this.state.person.map((data) => {
      return (
        <div>
          <span>{data.firstName}</span> <span>{data.lastName}</span> <span>{data.textArea}</span> <span>{data.phoneNumber}</span>
        </div>
      );
    });
  };

  render() {
    return (
      <div>
        <form onSubmit={(event) => this.handleSubmit(event)}>
          <input
            type="text"
            placeholder="Enter first name!"
            onChange={(event) => this.handleFirstNameChange(event)}
            value={this.state.firstName}
            required
          />
          <input
            type="text"
            placeholder ="Enter last name!"
            onChange={(event) => this.handleLastNameChange(event)}
            value={this.state.lastName}
            required
          />
          <input
            type="textarea"
            placeholder ="Enter text here!"
            onChange={(event) => this.handleTextAreaChange(event)}
            value={this.state.textArea}
            required
          />
          <input
            type="number"
            placeholder ="Enter phone number!"
            onChange={(event) => this.handlePhoneNumberChange(event)}
            value={this.state.phoneNumber}
            required
          />
          <input type="submit" />
        </form>
        {this.people()}
      </div>
    );
  }
}

export default InputForm;