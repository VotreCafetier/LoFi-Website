import { Outlet } from "react-router-dom";
import Nav from '../components/Nav';
import Footer from '../components/Footer';

const Layout = () => {
  return (
    <>
    <Nav></Nav>
    {/* Outlet serves as RenderBody */}
    <Outlet />
    <Footer></Footer>
    </>
  )
}

export default Layout