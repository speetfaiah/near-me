import React from 'react';
import { render } from 'react-dom';
import SearchFrom from './components/SearchFrom.jsx';
import Map from './components/Map.jsx';
import ResultList from './components/ResultList.jsx';

render(
    <div className="container">
        <div className="row">
            <div className="col-4">
                <SearchFrom />
            </div>
            <div className="col-8">
                <Map />
            </div>
        </div>
        <div className="row">
            <ResultList />
        </div>
    </div>,
    document.getElementById('react-container')
);