import React from "react";

class Counter extends React.Component{
state = {
    count:0
};
render(){
    return(
        <div>
            <span>{this.formatCount}</span>
            <button>Increment</button>
        </div>
    )
}
formatCount(){
    return this.state.count === 0 ? <h1>Zero</h1> : this.state.count;
}

}

export default Counter;