import { Outlet } from "react-router-dom";
import Nav from '../components/Nav';
import Footer from '../components/Footer';
import Alert from "../components/Alert";
import './Layout.css';
const Layout = () => {
  return (
    <>
    <Nav></Nav>
    <Alert alertType='0' message='Gros penis'/>
    {/* Outlet serves as RenderBody */}
    <section>
      <Outlet />
    </section>
    <Footer></Footer>
    </>
  )
}

export default Layout