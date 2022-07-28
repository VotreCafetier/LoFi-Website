import Home from './pages/Home';
import Error from './pages/Error';
import Layout from './pages/Layout';
import Login from './pages/Login';
import Register from './pages/Register';
import Shop from './pages/Shop';
import ForgotPassword from './pages/ForgotPassword';
import { BrowserRouter, Routes, Route } from "react-router-dom";

// this is a basic router
function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Layout />}>
                    <Route index element={<Home />} />
                    <Route path="/Login" element={<Login />} />
                    <Route path="/Register" element={<Register />} />
                    <Route path="/ForgotPassword" element={<ForgotPassword />} />
                    <Route path="/Shop" element={<Shop />} />
                    <Route path="*" element={<Error />} />
                </Route>
            </Routes>
        </BrowserRouter>
    );
  }

export default App;