import './App.css';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import ProtectedRoute from './pages/Router/ProtectedRoute';
import Auth from './pages/Auth/Auth';
import Login from './pages/Auth/Login';
import MainNavigation from './pages/Dashboard/MainNavigation';
import ProductosList from './pages/Productos/ProductosList';

function App() {

  return (
    <Router>
      <Routes>
        <Route path='/' element={<Navigate to='/app/productos' />}/>
        <Route path='/auth' element={<Auth/>}>
            <Route path='login' element={<Login />}/>
        </Route>
        <Route path='/app' element={<ProtectedRoute>
          <MainNavigation />
        </ProtectedRoute>}>
            <Route path='productos' element={<ProductosList/>}/>
        </Route>
      </Routes>
    </Router>
  )
}

export default App
