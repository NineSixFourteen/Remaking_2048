import React from "react";

class Home extends React.Component{

    constructor(){
        super();
        this.state = {
            pizza : "LALAL",
        }
    }

    componentDidMount(){
        this.getPizza();
    }

    async getPizza(){
        let temp = await fetch('pizza');
        console.log(temp);
        let pizza = await temp.json();
        console.log(pizza);
        this.setState({pizza:pizza[0].name});
    }

    render(){
        return <h1>{this.state.pizza}</h1>;
    }

} export default Home