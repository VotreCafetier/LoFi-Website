import React, { Component } from 'react'

export default class Footer extends Component {
    constructor(props) {
        super(props);
        this.state = {
            date: new Date().getFullYear()
        };
    }
    getDate() {
        let date = new Date().getFullYear();
        this.setState({
            date: date
        });
    }
    componentDidMount() {
        this.getDate();
    }
    render() {
        return (
            <footer className='text-center mt-4'>Dany Gauthier {this.state.date} | This site is powered by React and Bootstrap</footer>
        )
    }
}