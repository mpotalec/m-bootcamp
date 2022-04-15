import { useState } from "react";

function Student(){

    const showStudent = (e) => {
        e.preventDefault();
        console.log(data);
    }
  const [data, setData] = useState(
      {
          name: "",
          lastName: "",
          studentID: "",
      }
  );
    return(
        <div className="student">
            <form onSubmit={showStudent}>
                <input type="text" placeholder="Input Name" value={data.name} onChange={(e) => setData({... data, name: e.target.value})}/><br/>
                <input type="text" placeholder="Input Your Last Name" value={data.lastName} onChange={(e) => setData({... data, lastName: e.target.value})}/><br/>
                <input type="text" placeholder="Input Your Work ID" value={data.studentID} onChange={(e) => setData({... data, studentID: e.target.value})}/><br/>
                <br/><button type="submit" className="button-34">Submit</button><br/>
            </form>
            <p>{data.name}</p>
            <p>{data.lastName}</p>
            <p>{data.studentID}</p>
            
        </div>
    )
}


export default Student;