import { useNavigate, Outlet } from 'react-router-dom';
import { Navbar,Sidenav, Nav } from "rsuite";
import Avatar from 'rsuite/Avatar';
import AdminIcon from '@rsuite/icons/Admin';
import ExitIcon from '@rsuite/icons/Exit';
import DashboardIcon from '@rsuite/icons/legacy/Dashboard';
import GearCircleIcon from '@rsuite/icons/legacy/GearCircle';
import CharacterLockIcon from '@rsuite/icons/CharacterLock';
import PeoplesIcon from '@rsuite/icons/Peoples';
import LogIcon from '@rsuite/icons/Log';
import ReviewIcon from '@rsuite/icons/Review';
//import useGetUser from '../../hooks/useGetUser';
import './scss/main.content.scss';
import useCanAccess from '../../hooks/useCanAccess';
const MainNavigation = () => {
    const [menuPermission] = useCanAccess();
    //const [localUser] = useGetUser();
    const navigate = useNavigate();
    const logOut = () => {
        localStorage.clear();
        navigate('/auth/login');
    };
    return (
        <div>
            <Navbar appearance="inverse" >
                <Navbar.Brand style={{padding: '0px 30px'}}>
                    {/* <img src={LogoImg} width={200} /> */}
                    Sistema de Inventario y ventas
                </Navbar.Brand>
                <Nav pullRight>
                    <Nav.Item>
                        {/* {localUser.nombres}
                        <br/>
                        {localUser.role} */}
                    </Nav.Item>
                    <Nav.Menu icon={<Avatar circle />}>
                        <Nav.Item icon={<AdminIcon />} 
                        onClick={()=>{
                            navigate('dashboard')
                        }}>Ver Perfil</Nav.Item>
                        <Nav.Item icon={<ExitIcon />} onClick={()=>logOut()}>Salir</Nav.Item>
                    </Nav.Menu>
                </Nav>
            </Navbar>
                <div className="main-navigation">
                <div className="navbar-content">
                    <Sidenav appearance="subtle"
                    // defaultOpenKeys={['3', '4']}
                    >
                    <Sidenav.Body>
                        <Nav activeKey="1">
                        <Nav.Item eventKey="1" icon={<DashboardIcon />}
                            onClick={()=>{
                                navigate('dashboard')
                            }}
                        >
                            Inicio
                        </Nav.Item>
                        {
                           menuPermission.users &&
                           <Nav.Menu eventKey={"2"} title="Gestion de usuarios" icon={< PeoplesIcon/>}>
                                <Nav.Item onClick={()=>{
                                    navigate('users/list')
                                }}>Asignaciones usuarios</Nav.Item>
                            </Nav.Menu>
                        }
                        {
                            menuPermission.designacion &&
                            <Nav.Menu eventKey="3" title="Designaciónes de viajes" icon={<CharacterLockIcon />}>
                                <Nav.Item onClick={()=>{
                                    navigate('designacion/1')
                                }}>Designacion de viaje</Nav.Item>
                                <Nav.Item onClick={()=>{
                                    navigate('designacion/lista')
                                }}>Registro de designaciones</Nav.Item>
                            </Nav.Menu>
                        }
                            <Nav.Menu eventKey="4" title="Mis Solicitudes" icon={<GearCircleIcon />}>
                                <Nav.Item onClick={()=>{
                                    navigate('mis-designaciones')
                                }}>Mis Designaciones de viaje</Nav.Item>
                            </Nav.Menu>
                            {
                                menuPermission.presupuestos &&
                                <Nav.Menu eventKey={"5"} title="Certificaciones Presupuestarias" icon={<LogIcon />}>
                                <Nav.Item onClick={()=>{
                                    navigate('presupuesto/lista')
                                }} >
                                    Certificaciones Presupuestarias
                                    
                                </Nav.Item>
                            </Nav.Menu>}

                            {
                                menuPermission.planificacion &&    
                            <Nav.Menu eventKey={"6"} title="Certificaciones POA" icon={<ReviewIcon />}>
                                <Nav.Item onClick={()=>{
                                    navigate('certificacion/lista')
                                }} >
                                    Certificaciones POA
                                    
                                </Nav.Item>
                            </Nav.Menu>}
                            {menuPermission.pasajes &&
                                <Nav.Menu eventKey={"6"} title="Solicitudes de Pasajes" icon={<ReviewIcon />}>
                                    <Nav.Item onClick={()=>{
                                    navigate('solicitudes/lista')
                                        }} >
                                            Solicitudes de Viaje        
                                    </Nav.Item>
                                    <Nav.Item
                                        onClick={() => {
                                            navigate('pasajes/reporte')
                                        }}
                                        >
                                        Reporte de Pasajes
                                    </Nav.Item>
                                </Nav.Menu>
                            }
                        </Nav>
                    </Sidenav.Body>
                    </Sidenav>
                </div>
                <Outlet />
            </div>
        </div>
    )
}
export default MainNavigation;