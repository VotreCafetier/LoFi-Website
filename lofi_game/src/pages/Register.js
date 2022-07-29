import React from 'react'

const Register = () => {
  return (
    <form className='container'>
      <h1 className='mt-4'>Register</h1>

      <div className="form-group">
        <label for="Email" className="form-label mt-4">Username</label>
        <input type="email" className="form-control" id="Email" name='Email' placeholder="Username"/>
      </div>

      <div className="form-group">
        <label for="Email" className="form-label mt-4">Email address</label>
        <input type="email" className="form-control" id="Email" name='Email' placeholder="Enter email"/>
      </div>

      <div className="form-group">
        <label for="pwd" className="form-label mt-4">Password</label>
        <input type="password" className="form-control" id="pwd" name='pwd' placeholder="Password"/>
      </div>

      <div className="form-group">
        <label for="pwd" className="form-label mt-4">Confirm Password</label>
        <input type="password" className="form-control" id="pwd" name='pwd' placeholder="Confirm Password"/>
      </div>

      <div className="form-group text-center">
        <button type="submit" className="btn btn-primary mt-4">Register</button>
      </div>
    </form>
  )
}

export default Register