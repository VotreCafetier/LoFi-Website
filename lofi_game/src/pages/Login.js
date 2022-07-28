import React from 'react'

const Login = () => {
  return (
    <form className='container'>
      <h1>Login</h1>

      <div className="form-group">
        <label for="Email" className="form-label mt-4">Email address</label>
        <input type="email" className="form-control" id="Email" name='Email' placeholder="Enter email"/>
      </div>

      <div className="form-group">
        <label for="pwd" className="form-label mt-4">Password</label>
        <input type="password" className="form-control" id="pwd" name='pwd' placeholder="Password"/>
      </div>

      <div className="form-group text-center">
        <button type="submit" className="btn btn-primary mt-4">Submit</button>
      </div>
    </form>
  )
}

export default Login;