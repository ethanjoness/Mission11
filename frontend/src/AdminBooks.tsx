import React, { useState, useEffect } from 'react';
import axios from 'axios';

const API_URL = "https://ethanjones-bookstore-api.azurewebsites.net/api/books";

export default function AdminBooks() {
    const [books, setBooks] = useState<any[]>([]);
    const [form, setForm] = useState<any>({});

    useEffect(() => {
        fetchBooks();
    }, []);

    const fetchBooks = async () => {
        const response = await axios.get(API_URL);
        setBooks(response.data);
    };

    const handleDelete = async (id: number) => {
        await axios.delete(`${API_URL}/${id}`);
        fetchBooks();
    };

    const handleSave = async (e: React.FormEvent) => {
        e.preventDefault();
        if (form.bookID) {
            await axios.put(`${API_URL}/${form.bookID}`, form);
        } else {
            await axios.post(API_URL, form);
        }
        setForm({});
        fetchBooks();
    };

    return (
        <div className="row">
            <div className="col-4">
                <h4>{form.bookID ? "Edit Book" : "Add Book"}</h4>
                <form onSubmit={handleSave}>
                    <input className="form-control mb-2" placeholder="Title" value={form.title || ''} onChange={e => setForm({...form, title: e.target.value})} required />
                    <input className="form-control mb-2" placeholder="Author" value={form.author || ''} onChange={e => setForm({...form, author: e.target.value})} required />
                    <input className="form-control mb-2" placeholder="Publisher" value={form.publisher || ''} onChange={e => setForm({...form, publisher: e.target.value})} required />
                    <input className="form-control mb-2" placeholder="ISBN" value={form.isbn || ''} onChange={e => setForm({...form, isbn: e.target.value})} required />
                    <input className="form-control mb-2" placeholder="Classification" value={form.classification || ''} onChange={e => setForm({...form, classification: e.target.value})} required />
                    <input className="form-control mb-2" placeholder="Category" value={form.category || ''} onChange={e => setForm({...form, category: e.target.value})} required />
                    <input type="number" className="form-control mb-2" placeholder="Page Count" value={form.pageCount || ''} onChange={e => setForm({...form, pageCount: parseInt(e.target.value)})} required />
                    <input type="number" step="0.01" className="form-control mb-2" placeholder="Price" value={form.price || ''} onChange={e => setForm({...form, price: parseFloat(e.target.value)})} required />
                    <button type="submit" className="btn btn-success w-100">Save</button>
                    <button type="button" className="btn btn-secondary w-100 mt-2" onClick={() => setForm({})}>Clear</button>
                </form>
            </div>
            <div className="col-8">
                <table className="table table-striped">
                    <thead>
                        <tr><th>Title</th><th>Author</th><th>Price</th><th>Actions</th></tr>
                    </thead>
                    <tbody>
                        {books.map(b => (
                            <tr key={b.bookID}>
                                <td>{b.title}</td>
                                <td>{b.author}</td>
                                <td>${b.price}</td>
                                <td>
                                    <button className="btn btn-sm btn-warning me-2" onClick={() => setForm(b)}>Edit</button>
                                    <button className="btn btn-sm btn-danger" onClick={() => handleDelete(b.bookID)}>Delete</button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
}