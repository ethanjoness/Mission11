import React from 'react';
import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import AdminBooks from './AdminBooks';

function App() {
  return (
    <BrowserRouter>
      <div className="container mt-4">
        <div className="d-flex justify-content-between align-items-center mb-4">
            <h1 className="text-primary">Online Bookstore</h1>
            <nav>
              <Link to="/" className="btn btn-outline-primary me-2">Storefront</Link>
              <Link to="/adminbooks" className="btn btn-danger">Admin</Link>
            </nav>
        </div>
        
        <Routes>
          <Route path="/" element={
            <div className="alert alert-info">
              <h4>Storefront Coming Soon</h4>
              <p>For Phase 6, please click the "Admin" button above to access the database management tools.</p>
            </div>
          } />
          <Route path="/adminbooks" element={<AdminBooks />} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;