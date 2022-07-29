import React, { Component } from 'react'
import './Alert.css';


/**
 * 
 * This component serves as an alert
 * -- ALL OF THE PARAM ARE PROPS
 * 
 * @param alertType     id      Type of alert
 * @param header        string  Header of the alert
 * @param message       string  Message of the alert
 * @param dismissible   bool    Does the alert is dismissible
 * 
 */

// all of bootstrap classNamees for the alerts
const Type = [
    'primary',
    'secondary',
    'info',
    'warning',
    'danger',
    'success',
    'light'
];


export class Alert extends Component {
  constructor(props) {
    super(props);
    this.state = {
        dismissible: this.props.dismissible ?? true
    };
  }

  render() {
    return (
        <div className={`alert 
        ${this.state.dismissible ? 'alert-dismissible' : null }
        alert-${Type[this.props.alertType] ?? Type[0]} `}>
            {/* Btn dismiss */}
            {this.state.dismissible ? 
            <button type="button" className="btn-close" data-bs-dismiss="alert"></button> : null }
            {/* Header */}
            <strong>{this.props.header ?? ''}</strong> 
            {/* Message */}
            {this.props.message ?? ''}
        </div>
    )
  }
}

export default Alert;